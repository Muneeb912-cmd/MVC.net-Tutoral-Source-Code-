function LogOut() {
    alert("Successfully Loged Out!")
    goToMainPage();
}
function goToMainPage() {
    window.location = '/Home/Index';
}
function goToSignUpPage() {
    window.location = '/Home/Signup';
}
function SignUpPage() {
    
    goToSignUpPage();
}
function ManagerSignup() {

    goToManagerSignUpPage();
}
function goToManagerSignUpPage() {
    window.location = '/CEO/ManagerSignUp';
}
function EmailSent() {
    alert("Email Sent Successful")
}