window.addEventListener('DOMContentLoaded', (event) => {
    getVisitCount();
});


const localFunctionURL = 'http://localhost:7071/api/Counter'
const productionFunctionURL = 'https://moarserverless.azurewebsites.net/api/Counter?code=53CeMURqHdaBj9p8yI5HdOSiaCDFSARcltPvZWURaylYn8dRjpQ0Cg=='; 

const getVisitCount = () => {
    let count = 30;
    fetch(localFunctionURL)
    .then(response => {
        return response.json()
    })
    .then(response => {
        console.log("Website called function API.");
        count = response.count;
        document.getElementById('counter').innerText = count;
    }).catch(function(error) {
        console.log(error);
      });
    return count;
}
