function addTheme() {
    document.getElementById("add-theme-modal").classList.toggle("show");
}

function closeForm() {
    document.getElementById("add-theme-modal").classList.toggle("show");
}

function duplicateRound() {
    var original = document.getElementsByClassName('round-template');
    var i = document.getElementsByClassName('round-template').length;
    var clone = original[i - 1].cloneNode(true);
    clone.querySelector('.round-name-field').value = '';
    var questionCount = clone.getElementsByClassName('another-question').length;
    for (var q = 0; q < questionCount - 1; q++) {
        var question = clone.getElementsByClassName('another-question');
        question[0].parentNode.removeChild(question[0]);
    }
    original[i - 1].parentNode.appendChild(clone);
    document.getElementsByClassName('remove-another-round-btn')[i - 1].style.display = "block";
    var originalAddRound = document.getElementsByClassName('add-another-round-btn');
    originalAddRound[0].parentNode.removeChild(originalAddRound[0]);
}

function removeRound(e) {
    e.parentNode.parentNode.parentNode.removeChild(e.parentNode.parentNode);
}

function duplicateQuestion(e) {
    var original = e.parentNode.parentNode.parentNode.getElementsByClassName('another-question');
    var i = e.parentNode.parentNode.parentNode.getElementsByClassName('another-question').length;
    var clone = original[i - 1].cloneNode(true);
    original[i - 1].parentNode.appendChild(clone);
    e.parentNode.parentNode.parentNode.getElementsByClassName('remove-another-question-btn')[i - 1].style.display = "block";
    var originalAddQuestion = e.parentNode.parentNode.parentNode.getElementsByClassName('add-another-question-btn');
    originalAddQuestion[0].parentNode.removeChild(originalAddQuestion[0]);
}

function removeQuestion(e) {
    e.parentNode.parentNode.parentNode.removeChild(e.parentNode.parentNode);
}