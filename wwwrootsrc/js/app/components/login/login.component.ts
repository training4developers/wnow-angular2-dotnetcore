import { Component, Output, EventEmitter } from '@angular/core';

import { Account } from '../../services/account';
import { AppStorage } from '../../services/app-storage';

@Component({
	selector: 'lms-login',
	template: require('./login.component.html'),
	styles: [require('./login.component.scss')]
})
export class LoginComponent {

	emailAddress: string = 'bob@domain.com';
	password: string = 'test';

	@Output()
	loginSuccess: EventEmitter<void> = new EventEmitter<void>();

	@Output()
	loginFailure: EventEmitter<void> = new EventEmitter<void>();

	constructor(private account: Account, private appStorage: AppStorage) { }

	login(emailAddress: string, password: string) {

		this.account.login(emailAddress, password)
			.subscribe(result => {
				this.appStorage.set('AuthToken', result.accessToken);
				this.loginSuccess.emit();
			});

	}

}