import { Injectable } from '@angular/core';
import { Http, Headers, ConnectionBackend, RequestOptions, Request, RequestOptionsArgs, Response } from '@angular/http';
import { Observable } from 'rxjs';

import { AppStorage } from './app-storage';

@Injectable()
export class AuthorizedHttp extends Http {

	private _authToken: string;

  constructor (
		private appStorage: AppStorage,
		backend: ConnectionBackend,
		defaultOptions: RequestOptions
	) {	
    super(backend, defaultOptions);
  }

	request(url: string|Request, options?: RequestOptionsArgs): Observable<Response> {

		let headers: Headers;
		
		if (typeof url === 'string') {

			if (!options) {
				options = new RequestOptions();
			}

			if (!options.headers) {
				options.headers = new Headers();
			}

			headers = options.headers;

		} else {
			
			headers = url.headers;
		
		}

		if (!headers.has('Authorization')) {
			headers.append('Authorization', `Bearer ${this.appStorage.get('AuthToken')}`);
		} else {
			console.warn('Authorization header already set.');
		}
    
		return super.request(url, options);        
  }
}