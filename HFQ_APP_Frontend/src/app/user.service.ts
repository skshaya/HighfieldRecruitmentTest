import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserBO, UserViewModel } from './models/user';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private apiUrl = 'https://localhost:44334'; // Replace with your  API URL

  constructor(private http: HttpClient) {}

  getUserColorAndAgeDetails(): Observable<UserViewModel> { // Get All user Details 

    return this.http.get<UserViewModel>(`${this.apiUrl}/api/user/details`);

  }
}
