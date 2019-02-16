import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.prod';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class TranslatorBackendService {
  url = environment.rootUrl;

  constructor(private http: HttpClient) { }

  public getByWord(word: string): Observable<any> {
      return this.http.get<any>(`${this.url}?from=${word}`);
  }

  public postWord(word: {word: string}): Observable<any> {
    return this.http.post(`${this.url}`, word, this.generateHeaders());
  }

  private generateHeaders() {
    return {
        headers: new HttpHeaders({
          'Content-Type': 'application/json'
        })
    };
  }
}
