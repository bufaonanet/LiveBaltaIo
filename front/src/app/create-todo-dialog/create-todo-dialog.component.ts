import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-create-todo-dialog',
  templateUrl: './create-todo-dialog.component.html',
  styleUrls: ['./create-todo-dialog.component.css'],
})
export class CreateTodoDialogComponent implements OnInit {
  public form: FormGroup;

  constructor(
    public dialog: MatDialogRef<CreateTodoDialogComponent>,
    private fb: FormBuilder
  ) {
    this.form = fb.group({
      title: [
        '',
        Validators.compose([
          Validators.minLength(3),
          Validators.maxLength(20),
          Validators.required,
        ]),
      ],
    });
  }

  ngOnInit(): void {}

  close() {
    this.dialog.close();
  }

  submit() {
    this.dialog.close(this.form.value);
  }
}
