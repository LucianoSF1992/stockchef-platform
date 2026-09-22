import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatTableModule } from '@angular/material/table';

import { CategoriesService } from '../../services/categories';
import { Category } from '../../models/category.model';

@Component({
  selector: 'app-categories',
  imports: [
    CommonModule,
    MatProgressSpinnerModule,
    MatTableModule,
  ],
  templateUrl: './categories.html',
  styleUrl: './categories.scss',
})
export class Categories implements OnInit {
  categories: Category[] = [];

  protected readonly displayedColumns = [
    'name',
    'description',
    'isActive',
    'actions',
  ];

  isLoading = false;
  errorMessage = '';

  constructor(private readonly categoriesService: CategoriesService) { }

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
      error: (error) => {
        console.error('Erro ao carregar categorias:', error);

        this.errorMessage =
          'Não foi possível carregar as categorias.';

        this.isLoading = false;
      },
    });
  }
}