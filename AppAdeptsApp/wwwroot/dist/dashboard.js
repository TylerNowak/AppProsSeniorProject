const modal = document.querySelector('.modal');
const modalHeading = document.querySelector('.modal-heading');
const modalSummary = document.querySelector('.modal-summary');
const modalDescription = document.querySelector('.modal-description');
const closeBtn = document.querySelector('.close-btn');

const edit = (event) => {
    event.stopPropagation();
}

const showIssue = (element) => {
    modalHeading.innerHTML = 'Issue: ' + element.children[0].innerHTML;
    modalSummary.innerHTML = element.children[1].innerHTML;
    modalDescription.innerHTML = element.children[2].innerHTML;
    modal.classList.add('show-modal');
};

const closeIssue = () => {
    modal.classList.remove('show-modal');
}

closeBtn.addEventListener('click', closeIssue); 