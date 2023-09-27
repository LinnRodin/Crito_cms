document.addEventListener('DOMContentLoaded', () => {
    const form = document.getElementById('contactForm');
    const nameField = document.getElementById('name');
    const emailField = document.getElementById('email');
    const messageField = document.getElementById('message');
    const nameError = document.getElementById('name-error');
    const emailError = document.getElementById('email-error');
    const messageError = document.getElementById('message-error');
    const thankYouMessage = document.getElementById('thank-you-message');
    
    nameField.addEventListener('input', () => {
        if (nameField.value.trim() === '') {
            nameError.textContent = 'Name is required';
        } else if (nameField.value.trim().length < 3) {
            nameError.textContent = 'Name must be at least 3 characters';
        } else {
            nameError.textContent = '';
        }
    });

    emailField.addEventListener('input', () => {
        if (emailField.value.trim() === '') {
            emailError.textContent = 'Email is required';
        } else if (!emailField.value.includes('@')) {
            emailError.textContent = 'Please enter a valid email address';
        } else {
            emailError.textContent = '';
        }
    });

    messageField.addEventListener('input', () => {
        if (messageField.value.trim() === '') {
            messageError.textContent = 'Message is optional';
        } else {
            messageError.textContent = '';
        }
    });

    form.addEventListener('submit', (e) => {
        e.preventDefault();
        if(nameField.value.trim() !== '' && nameField.value.trim().length >= 3 && emailField.value.includes('@')) {
            thankYouMessage.textContent = 'Thank you!';
            form.reset();
        } else {
            thankYouMessage.textContent = 'Please fill in all required fields correctly.';
        }
    });
});


                        