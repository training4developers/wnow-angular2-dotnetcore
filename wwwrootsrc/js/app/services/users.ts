import { Injectable } from '@angular/core';
import { BaseRestClient } from './base-rest-client';
import { AuthorizedHttp } from './authorized-http';
import { User } from '../models/user';

@Injectable()
export class Users extends BaseRestClient<User> {

	constructor(http: AuthorizedHttp) {
		super(http, 'users');
	}
}