import { Component, OnInit, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatTableModule } from '@angular/material/table';

import { Category } from '../../models/category.model';
import { CategoriesService } from '../../services/categories';

@Component({
  selector: 'app-categories',
  standalone: true,
  imports: [
    MatButtonModule,
    MatProgressSpinnerModule,
    MatTableModule,
  ],
  templateUrl: './categories.html',
  styleUrl: './categories.scss',
})
export class Categories implements OnInit {
  private readonly categoriesService = inject(CategoriesService);

  categories: Category[] = [];
  isLoading = false;
  errorMessage = '';

  displayedColumns: string[] = [
    'name',
    'description',
    'status',
  ];

  ngOnInit(): void {
    this.loadCategories();
  }

  loadCategories(): void {
    this.isLoading = true;
    this.errorMessage = '';

    this.categoriesService.getAll().subscribe({
      next: (categories) => {
        this.categories = categories;
        this.isLoading = false;
      },
      error: () => {
        this.errorMessage =
          'Não foi possível carregar as categorias.';
        this.isLoading = false;
      },
    });
  }
}