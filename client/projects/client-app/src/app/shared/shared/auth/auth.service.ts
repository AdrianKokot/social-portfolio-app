import { Injectable } from "@angular/core";
import { environment } from "../../../../environments/environment";
import { HttpClient } from "@angular/common/http";
import { UserLoginModel, UserRegisterModel } from "../models/auth/auth-models";
import { BehaviorSubject, map, Observable } from "rxjs";
import { ApplicationUser } from "../models/auth/application-user";
import { User } from "../models/auth/user";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl = environment.backendUrl + 'authentication';
  private actions = {
    login: this.baseUrl + '/login',
    register: this.baseUrl + '/register'
  };

  private _user$ = new BehaviorSubject<ApplicationUser | null>(this.readUserFromStorage());

  public get user$(): Observable<User | null> {
    return this._user$
      .pipe(
        map(appUser =>
          appUser !== null
            ? {email: appUser.email, name: appUser.name} as User
            : null
        )
      );
  }

  public get token$(): Observable<string | null> {
    return this._user$.pipe(
      map(user => user?.token || null)
    );
  }

  public get isLoggedIn$(): Observable<boolean> {
    return this._user$
      .pipe(
        map(user => {
          return user !== null;
        })
      );
  }

  constructor(private http: HttpClient) {
  }

  private readUserFromStorage(): ApplicationUser | null {
    const valueFromStorage = localStorage.getItem('user');
    return valueFromStorage == null ? null : JSON.parse(valueFromStorage) as ApplicationUser;
  }

  private setUser(user: ApplicationUser): void {
    localStorage.setItem('user', JSON.stringify(user));
    this._user$.next(user);
  }

  public login(userData: UserLoginModel): Observable<void> {
    return this.http.post<ApplicationUser>(this.actions.login, userData)
      .pipe(
        map(user => {
          this.setUser(user);
        })
      )
  }

  public register(userData: UserRegisterModel) {
    return this.http.post<ApplicationUser>(this.actions.register, userData)
      .pipe(
        map(user => {
          this.setUser(user);
        })
      )
  }

  public logout(): Observable<boolean> {
    localStorage.removeItem('user');
    this._user$.next(null);
    return this.isLoggedIn$.pipe(map(x => !x));
  }
}
