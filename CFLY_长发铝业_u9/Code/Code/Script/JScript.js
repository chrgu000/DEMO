
function ReferenceServiceMethod1() {
    WebServiceTest.HelloWorld(GetResult);
}
function GetResult(result) {
    alert(result);
}

function ReferencSercviceMethod2() {
    WebServiceTest.SayHelloWorld(document.getElementById("txtName").value, GetResult);
}