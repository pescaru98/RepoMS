
function getXMLDocObject(xmlFile, callback) {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if ((this.readyState === 4) && (this.status === 200)) {
            var xmlContent = this.responseText;
            var xmlDoc = parseXML(xmlContent);
            callback(xmlDoc);
        }
    };
    xhttp.open('GET', xmlFile, false);
    xhttp.send();
}

// parse a text string into an XML DOM object
function parseXML(xmlContent) {
    var parser = new DOMParser();
    var xmlDoc = parser.parseFromString(xmlContent, 'text/xml');
    return xmlDoc;
}