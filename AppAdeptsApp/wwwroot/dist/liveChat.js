/**** CSS Stuff ****/
const containerElement = document.querySelector('.overflow')
const scrollToBottomOfChat = () =>
  containerElement.scrollTop = containerElement.scrollHeight - containerElement.clientHeight
// start the page at the bottom of the chat list.
scrollToBottomOfChat()

/**** Various Utilities ****/
const toMilliSeconds = seconds => seconds * 1000
const defaultDelay = toMilliSeconds(5)
const isLeftMessage = (message) => message.includes("AppPros") ? "left" : "right"
// pull the "Index" off of the /Index in the browser url.
const buildEndpointUrl = endpoint =>
  window.location.href.replace(/.*\/Index/, '') + endpoint

const getMessageListElements = () => containerElement.children
// sets the first element in the history to the initial value from the server,
// this way we can reset the messages to their original state if we run into an error
const containerElementHistory = [getMessageListElements()]

/**** Message creation stuff ****/

function addMessageNodes(messageTexts) {
  const createNode = (message) => {
    const newMessageElement = document.createElement("p")
    const classList = ["text-message", `${isLeftMessage(message)}-message`]
    newMessageElement.classList.add(...classList)
    newMessageElement.textContent = message
    containerElement.append(newMessageElement) // prepending puts the messages in the order we need
  }

  containerElement.replaceChildren()
  // formatMessages(messageTexts).forEach(createNode)
  messageTexts.forEach(createNode)
  scrollToBottomOfChat()
  return containerElement.children
}

/**** Message Refresh Stuff ****/
const generateInterval = func => delay => {
  let interval = setInterval(() => {
    func()
  }, delay)
  const changeInterval = (newDelay = delay) => {
    func()
    clearInterval(interval)
    interval = setInterval(func, newDelay)
  }
  return [
    interval,
    changeInterval,
    { func, delay },
  ]
}

const handleUpdateMessageList = () => [
  () => containerElementHistory.push(getMessageListElements()),
  () => containerElement.replaceChildren(...containerElementHistory[containerElementHistory.length - 1])
]

const fetchChatHistory = () => {
  const [addMessageHistory, replaceMessages] = handleUpdateMessageList()
  return fetch(buildEndpointUrl("RefreshChatHistory"))
    .then(response => response.json())
    .then(response => {
      console.log(response)
      const messages = response.messages
      addMessageNodes(messages)

      // add the new list to the history
      addMessageHistory()
      return messages
    })
    .catch(err => {
      // replace the list with the original
      replaceMessages()
      console.error(err)
    })
}
// countdown to stop polling until new [typing] input.
const startCountdown = () => setTimeout(() => {
  console.log('ending interval')
  clearInterval(interval)
}, toMilliSeconds(10.5))

// allow to kill the timeout
let timeout = null
const resetAll = (delay = defaultDelay) => {
  changeInterval(delay)
  timeout = startCountdown()
}

/**** Do all the things ****/
const createChatRefreshInterval = generateInterval(fetchChatHistory)
let [interval, changeInterval, { delay }] = createChatRefreshInterval(defaultDelay)

// Set up event handler for text input
const sendButton = document.querySelector('button[type="submit"]')
const textField = document.querySelector('input[type="text"]')
sendButton.addEventListener('click', (e) => {
  console.log('click event')
  resetAll()
})
textField.addEventListener('focusin', () => {
  console.log('focusin event')
  clearTimeout(timeout)
  changeInterval(toMilliSeconds(1));
})
textField.addEventListener('focusout', () => {
  console.log('focusout event')
  resetAll()
})

// start the countdown on window load, so that we don't have an endless stream of calls.
timeout = startCountdown()

// Turn off the interval on window close and navigate away for safety
window.addEventListener('unload', () => {
  clearTimeout(timeout)
  clearInterval(interval)
})
