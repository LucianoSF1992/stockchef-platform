import { Component, EventEmitter, Input, Output, inject } from '@angular/core';
import {
  FormBuilder,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

import { Category } from '../../models/category.model';
import { CreateCategory } from '../../models/create-category.model';

@Component({
  selector: 'app-category-form',
  imports: [
    ReactiveFormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
  ],
  templateUrl: './category-form.html',
  styleUrl: './category-form.scss',
})
export class CategoryForm {
  private readonly formBuilder = inject(FormBuilder);

  @Input() category: Category | null = null;

  @Output() saved = new EventEmitter<CreateCategory>();
  @Output() cancelled = new EventEmitter<void>();

  protected readonly form = this.formBuilder.nonNullable.group({
    name: ['', [Validators.required, Validators.maxLength(100)]],
    description: ['', [Validators.maxLength(500)]],
  });

  protected get isEditing(): boolean {
    return this.category !== null;
  }

  ngOnChanges(): void {
    if (this.category) {
      this.form.patchValue({
        name: this.category.name,
        description: this.category.description ?? '',
      });
    } else {
      this.form.reset({
        name: '',
        description: '',
      });
    }
  }

  protected onSubmit(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    const value = this.form.getRawValue();

    this.saved.emit({
      name: value.name.trim(),
      description: value.description.trim() || null,
    });
  }

  protected onCancel(): void {
    this.cancelled.emit();
  }
}