function downloadFile(filename, filecontent) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64," + filecontent;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}