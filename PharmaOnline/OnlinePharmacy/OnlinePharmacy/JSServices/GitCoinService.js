function getLabelsOfArray(array) {
    const labels = []
    array.forEach(item => labels.push(getHourFromDate(new Date(item.issue_date))));
    labels.sort(compareByDate);
    return labels;
}

function getDataOfArray(array) {
    array.sort(compareByDateObj);
    const dataArray = [];
    array.forEach(item => dataArray.push(parseFloat(item.price)));
    const data = {
        labels: getLabelsOfArray(array),
        datasets: [{
            label: 'Gitcoin',
            backgroundColor: '#ffc107',
            borderColor: '#ffc107',
            data: dataArray,
        }]
    };
    return data;
}

function compareByDateObj(objA, objB) {
    if (objA.issue_date < objB.issue_date) {
        return -1;
    }
    if (objA.issue_date > objB.issue_date) {
        return 1;
    }
    return 0;
}

function getXMLObj(xml) {
    let myArray = [];
    getXMLDocObject(xml, function (xmlDoc) {

        // extract the info from the xmlDoc object
        var arrayOfRecords = xmlDoc.getElementsByTagName('ArrayOfGitCoinRecord')[0];
        var records = arrayOfRecords.getElementsByTagName('GitCoinRecord')

        for (var i = 0; i < records.length; i++) {

            var record_id = records[i].children[0].nodeName;
            var record_id_value = records[i].children[0].innerHTML;

            var price = records[i].children[1].nodeName;
            var price_value = records[i].children[1].innerHTML;

            var issue_date = records[i].children[2].nodeName;
            var issue_date_value = records[i].children[2].innerHTML;

            myArray.push({ record_id: record_id_value, price: price_value, issue_date: issue_date_value });

        }


    });
    return myArray
}

function getArrayDiff(arrayOld, arrayNew) {
    return arrayOld.filter(item => !isObjectInArray(arrayNew, item));
}

function isObjectInArray(array, object) {
    const arr = array.filter(item => JSON.stringify(item) == JSON.stringify(object));
    if (arr.length != 0)
        return true;
    return false;
}