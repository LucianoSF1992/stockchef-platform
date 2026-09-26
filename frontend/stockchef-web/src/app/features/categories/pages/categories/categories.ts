import { Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatButtonModule } from '@angular/material/button';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatTableModule } from '@angular/material/table';

import { CategoriesService } from '../../services/categories';
import { Category } from '../../models/category.model';
import { CreateCategory } from '../../models/create-category.model';
import { CategoryForm } from '../../components/category-form/category-form';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-categories',
  imports: [
    CommonModule,
    MatButtonModule,
    MatIconModule,
    MatProgressSpinnerModule,
    MatTableModule,
    CategoryForm,
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
    'actions',
  ];

  protected readonly isLoading = signal(false);
  protected readonly isSaving = signal(false);
  protected readonly errorMessage = signal('');
  protected readonly showForm = signal(false);
  protected readonly selectedCategory = signal<Category | null>(null);

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
          'Não foi possível carregar as categorias.',
        );

        this.isLoading.set(false);
      },
    });
  }

  protected openCreateForm(): void {
    this.selectedCategory.set(null);
    this.showForm.set(true);
  }

  protected closeCreateForm(): void {
    this.showForm.set(false);
    this.selectedCategory.set(null);
  }

  protected openEditForm(category: Category): void {
    this.selectedCategory.set(category);
    this.showForm.set(true);
  }

  protected createCategory(category: CreateCategory): void {
    this.isSaving.set(true);
    this.errorMessage.set('');

    this.categoriesService.create(category).subscribe({
      next: () => {
        this.isSaving.set(false);
        this.showForm.set(false);
        this.loadCategories();
      },
      error: (error) => {
        console.error('Erro ao criar categoria:', error);

        this.errorMessage.set(
          'Não foi possível criar a categoria.',
        );

        this.isSaving.set(false);
      },
    });
  }

  protected updateCategory(category: CreateCategory): void {
    const selectedCategory = this.selectedCategory();

    if (!selectedCategory) {
      return;
    }

    this.isSaving.set(true);
    this.errorMessage.set('');

    this.categoriesService
      .update(selectedCategory.id, {
        id: selectedCategory.id,
        name: category.name,
        description: category.description,
      })
      .subscribe({
        next: () => {
          this.isSaving.set(false);
          this.closeCreateForm();
          this.loadCategories();
        },
        error: (error) => {
          console.error('Erro ao atualizar categoria:', error);

          this.errorMessage.set(
            'Não foi possível atualizar a categoria.',
          );

          this.isSaving.set(false);
        },
      });
  }
}