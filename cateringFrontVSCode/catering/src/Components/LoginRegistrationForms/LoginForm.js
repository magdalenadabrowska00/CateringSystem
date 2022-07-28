import React, {useState} from 'react';
//import './style.css';

export default function LoginForm(){
    return (
        <div className='form'>
            <div className='form-body'>
                <div className='useremail'>
                    <label className='form_label' for="UserEmail">Email</label>
                    <input className="form__input" type="text" id="email" placeholder="Email"/>
                </div>
                <div className='password'>
                    <label className='form_label' for="Password">Password</label>
                    <input className="form__input" type="text" id="password" placeholder="Password"/>
                </div>
            </div>
            <div className='footer'>
                <button type="submit" class="btn">Login</button>
            </div>
        </div>
    )
}

function handleSubmit(event) {
    event.preventDefault();
}