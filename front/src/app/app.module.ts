import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';

import { CreateTodoDialogComponent } from './create-todo-dialog/create-todo-dialog.component';
import { HomePageComponent } from './home-page/home-page.component';
import { JoinPageComponent } from './join-page/join-page.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { AuthGuard } from './guards/guard';

@NgModule({
  declarations: [
    AppComponent,
    CreateTodoDialogComponent,
    HomePageComponent,
    JoinPageComponent,
    LoginPageComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatCardModule,
    MatButtonModule,
    MatInputModule,
    MatSnackBarModule,
    MatToolbarModule,
    MatIconModule,
    MatDialogModule,

  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent],
})
export class AppModule {}
