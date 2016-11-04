import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AppStorage } from '../services/app-storage';

export class BaseAuthorizedComponent implements OnInit {

	constructor(private router: Router, private appStorage: AppStorage) { }

	ngOnInit() {
		if (!this.appStorage.get('AuthToken')) {
			this.router.navigateByUrl('/');
		}
	}

}