function addTheme() {
    document.getElementById("add-theme-modal").classList.toggle("show");
}

function closeForm() {
    document.getElementById("add-theme-modal").classList.toggle("show");
}

function duplicateRound(id) {
    //let input = document.getElementsByClassName('round-name-field').value;
    //if (!input == "") {
    let original = document.getElementsByClassName('round-template');
    let i = document.getElementsByClassName('round-template').length;
    let clone = original[i - 1].cloneNode(true);
    clone.querySelector('.round-name-field').value = '';
    let questionCount = clone.getElementsByClassName('another-question').length;
    for (let q = 0; q < questionCount - 1; q++) {
        let question = clone.getElementsByClassName('another-question');
        question[0].parentNode.removeChild(question[0]);
    }
    original[i - 1].parentNode.appendChild(clone);
    document.getElementsByClassName('remove-another-round-btn')[i - 1].style.display = "block";
    let originalAddRound = document.getElementsByClassName('add-another-round-btn');
    originalAddRound[0].parentNode.removeChild(originalAddRound[0]);
    //}
    //else {
    //    document.getElementsByClassName('input-alert').classList.toggle("show");
    //    return false;
    //}
}

function removeRound(e) {
    e.parentNode.parentNode.parentNode.removeChild(e.parentNode.parentNode);
}

function duplicateQuestion(e) {
    let original = e.parentNode.parentNode.parentNode.getElementsByClassName('another-question');
    let i = e.parentNode.parentNode.parentNode.getElementsByClassName('another-question').length;
    let clone = original[i - 1].cloneNode(true);
    original[i - 1].parentNode.appendChild(clone);
    e.parentNode.parentNode.parentNode.getElementsByClassName('remove-another-question-btn')[i - 1].style.display = "block";
    let originalAddQuestion = e.parentNode.parentNode.parentNode.getElementsByClassName('add-another-question-btn');
    originalAddQuestion[0].parentNode.removeChild(originalAddQuestion[0]);
}

function removeQuestion(e) {
    e.parentNode.parentNode.parentNode.removeChild(e.parentNode.parentNode);
}

function saveRound(e, id) {
    let title = e.querySelector('.round-name-field').value;
    $.ajax({
        type: "POST",
        url: "/Round/Create/" + id,
        data: { 'RoundTitle': title },
        beforeSend: function (request) {
            request.setRequestHeader("RequestVerificationToken", $("[name='__RequestVerificationToken']").val());
        }
    });
}

async function submitAll(form, gameId) {
    const roundBlocks = document.querySelectorAll(".round-template");
    let roundQuestionsArray = [];
    roundBlocks.forEach(element => {
        //saveRound(element, gameId);
        let roundTitle = element.querySelector(".round-name-field").value;
        const questionBlock = element.querySelectorAll(".select-question-dropdown");
        questionBlock.forEach(element => {
            const roundObject = {
                RoundId: roundTitle,
                QuestionId: element.value
            };
            roundQuestionsArray.push(roundObject);
        });
    });
    console.log(JSON.stringify(roundQuestionsArray));
    await sendRequestAsync(roundQuestionsArray, "https://localhost:5001/Round/AddRoundQuestion")
    //$.ajax({
    //    type: form.method,
    //    url: form.action,
    //    data: JSON.stringify(roundQuestionsArray)
    //});
}

async function sendRequestAsync(model, url) {
    const response = await fetch(url, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(model)
    });
    const data = await response.json();
    return data;
}