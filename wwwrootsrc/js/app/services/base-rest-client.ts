import { Http, Headers, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs';
import { Element } from '../models/element';

export abstract class BaseRestClient<T extends Element> {

	private readonly _headers: Headers = new Headers({
		'Content-Type': 'application/json'
	});
	
	private readonly _requestOptions: RequestOptions = new RequestOptions({
		headers: this._headers
	});

	constructor(private http: Http, private elementPathSegment: string) { }

	getAll(): Observable<T[]> {
		return this.http.get(`/${this.elementPathSegment}`).map(res => res.json());
	}

	get(elementId: number): Observable<T> {
		return this.http.get(`/${this.elementPathSegment}/${encodeURIComponent(elementId.toString())}`)
			.map(res => res.json());
	}

	insert(element: T): Observable<T> {
		return this.http.post(`/${this.elementPathSegment}`, JSON.stringify(element),
			this._requestOptions).map(res => res.json());
	}

	// only return Observable<Response> when using 204 NoContent for REST service responses
	update(element: T): Observable<Response> {
		return this.http.put(`/${this.elementPathSegment}/${encodeURIComponent(element.id.toString())}`,
			JSON.stringify(element), this._requestOptions);
	}

	delete(elementId: number): Observable<Response> {
		return this.http.delete(`/${this.elementPathSegment}/${encodeURIComponent(elementId.toString())}`);
	}
}