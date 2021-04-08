function getLatestN(n, array) {
    if (array.length <= n)
        return array;
    return array.slice(array.length-1-n, array.length-1);
}

function getHourFromDate(date) {
    let hours;
    let minutes;
    if (date.getHours() < 10) {
        hours = "0" + date.getHours();
    } else {
        hours = date.getHours();
    }

    if (date.getMinutes() < 10) {
        minutes = "0" + date.getMinutes();
    } else {
        minutes =  date.getMinutes();
    }
    return hours + ":" + minutes;
}

function compareByDate(a, b) {
    if (new Date(a) < new Date(b)) {
        return -1;
    }
    if (new Date(a) > new Date(b)) {
        return 1;
    }
    return 0;
}


