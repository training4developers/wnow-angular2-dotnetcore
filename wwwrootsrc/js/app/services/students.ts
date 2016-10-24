import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';

import { AuthorizedHttp } from './authorized-http';
import { Student } from '../models/student';

@Injectable()
export class Students {

	constructor(private http: AuthorizedHttp) { }

	getAll(): Observable<Student[]> {
		return this.http.get('/students').map(res => res.json());
	}

}