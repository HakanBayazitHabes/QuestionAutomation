const startingMinutes = 10;
let time = startingMinutes * 60;

const countdownEl = document.getElementById('countdown');
let refreshIntervalId = setInterval(updateCountDown, 1000); //her 1 saniyede güncelle


function updateCountDown() {
    const minutes = Math.floor(time / 60);
    let seconds = time % 60;

    seconds = seconds < 10 ? '0' + seconds : seconds;

    countdownEl.innerHTML = `${minutes}: ${seconds}`;
    time--;

    if (time < 0) { //time negatifden kurtarmak için kurtuluruz
        clearInterval(refreshIntervalId);
        countdownEl.innerHTML = `SüreDoldu`;
    }
}