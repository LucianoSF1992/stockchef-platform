import { Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatButtonModule } from '@angular/material/button';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatTableModule } from '@angular/material/table';

import { CategoriesService } from '../../services/categories';
import { Category } from '../../models/category.model';

@Component({
  selector: 'app-categories',
  imports: [
    CommonModule,
    MatButtonModule,
    MatProgressSpinnerModule,
    MatTableModule,
  ],
  templateUrl: './categories.html',
  styleUrl: './categories.scss',
})
export class Categories implements OnInit {
  protected readonly categories = signal<Category[]>([]);

  protected readonly displayedColumns = [
    'name',
    'description',
    'status',
  ];

  protected readonly isLoading = signal(false);
  protected readonly errorMessage = signal('');

  constructor(private readonly categoriesService: CategoriesService) { }

  ngOnInit(): void {
    this.loadCategories();
  }

  protected loadCategories(): void {
    this.isLoading.set(true);
    this.errorMessage.set('');

    this.categoriesService.getAll().subscribe({
      next: (categories) => {
        this.categories.set(categories);
        this.isLoading.set(false);
      },
      error: (error) => {
        console.error('Erro ao carregar categorias:', error);

        this.errorMessage.set(
          'Não foi possível carregar as categorias.'
        );

        this.isLoading.set(false);
      },
    });
  }
}