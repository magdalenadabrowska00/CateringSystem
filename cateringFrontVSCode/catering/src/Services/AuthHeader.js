export default function AuthHeader() {
    const email = JSON.parse(localStorage.getItem("email"));
    if(email && email.accessToken) {
        return { Authorization: 'Bearer' + email.accessToken};
    } else {
        return {};
    }
}