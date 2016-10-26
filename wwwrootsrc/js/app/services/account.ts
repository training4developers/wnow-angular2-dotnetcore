import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Observable } from 'rxjs';

@Injectable()
export class Account {

	constructor(private http: Http) { }

	login(emailAddress: string, password: string) {

		return this.http.post('/account/login', {
			emailAddress, password
		}, {
			headers: new Headers({ 'Content-Type': 'application/json' })
		}).map(res => res.json());

	}

}