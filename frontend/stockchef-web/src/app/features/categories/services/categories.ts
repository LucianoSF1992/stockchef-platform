import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Category } from '../models/category.model';
import { CreateCategory } from '../models/create-category.model';
import { UpdateCategory } from '../models/update-category.model';

@Injectable({
  providedIn: 'root',
})
export class CategoriesService {
  private readonly apiUrl = 'http://localhost:5009/api/Categories';

  constructor(private readonly http: HttpClient) { }

  getAll(): Observable<Category[]> {
    return this.http.get<Category[]>(this.apiUrl);
  }

  getById(id: string): Observable<Category> {
    return this.http.get<Category>(`${this.apiUrl}/${id}`);
  }

  create(category: CreateCategory): Observable<string> {
    return this.http.post<string>(this.apiUrl, category);
  }

  update(id: string, category: UpdateCategory): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, category);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}