import { Injectable, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Response } from '../Interfaces/IResponse';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private nomeUsuario: string;


  private currentResponseSubject: BehaviorSubject<Response>;
  public currentResponse: Observable<Response>;

  constructor(private http: HttpClient) {
    this.currentResponseSubject = new BehaviorSubject<Response>(JSON.parse(localStorage.getItem('currentResponse')));
    this.currentResponse = this.currentResponseSubject.asObservable();
  }

  public get currentResponseValue(): Response {
    return this.currentResponseSubject.value;
  }


  login(username: string, password: string) {
    //return this.http.post<User>('/api/authentication/login', { username, password })

    const headers = new HttpHeaders({ Authorization: 'Basic ' + btoa(username + ':' + password) });

    return this.http.post<Response>('https://dev.sitemercado.com.br/api/login',null, { headers })
      .pipe(map(response => {
        // store user details and jwt token in local storage to keep user logged in between page refreshes
        if (response.success) {
          localStorage.setItem('currentResponse', JSON.stringify(response));
          this.currentResponseSubject.next(response);
        }
        return response;
      }));
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
    this.currentResponseSubject.next(null);
  }

}
