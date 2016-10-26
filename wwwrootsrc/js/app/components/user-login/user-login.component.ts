import { Component, Output, EventEmitter } from '@angular/core';

import { Account } from '../../services/account';
import { AppStorage } from '../../services/app-storage';

@Component({
	selector: 'user-login',
	template: require('./user-login.component.html'),
	styles: [require('./user-login.component.scss')]
})
export class UserLoginComponent {

	emailAddress: string = 'bob@localhost';
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