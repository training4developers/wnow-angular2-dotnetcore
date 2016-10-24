import { Injectable } from '@angular/core';

@Injectable()
export class AppStorage {

	private _map: Map<string, any> = new Map<string, any>();

	has(key: string) {
		return this._map.has(key);
	}

	remove(key: string) {
		this._map.delete(key);
		return this;
	}

	get(key: string): any {
		return this._map.get(key);
	}

	set(key: string, value: any) {
		this._map.set(key, value);
		return this;
	}
}