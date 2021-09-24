import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AddBookComponent } from './Books/add-book/add-book.component';
import { BookCardComponent } from './Books/book-card/book-card.component';
import { BookDetailComponent } from './Books/book-detail/book-detail.component';
import { BookListComponent } from './Books/book-list/book-list.component';
import { NavbarComponent } from './navbar/navbar/navbar.component';
import { UserLoginComponent } from './User/user-login/user-login.component';
import { UserRegisterComponent } from './User/user-register/user-register.component';
import { HttpClientModule  } from '@angular/common/http';
import { BookingService } from './Services/booking.service';
import { HeaderComponent } from './navbar/header/header.component';
import { Routes,RouterModule } from '@angular/router';
import { CartComponent } from './Cart/cart/cart.component';


const appRoutes: Routes=[
 {path:'buy',component:BookListComponent},
 {path:'sell-book',component:AddBookComponent},
 {path:'',component:BookListComponent},
 {path: 'user-login', component:UserLoginComponent},
 {path:'user-register', component:UserRegisterComponent},
 {path:'cart', component:CartComponent},
 {path:'bookdetail/:id', component: BookDetailComponent},






 {path:'**', component:BookListComponent},

]
@NgModule({
  declarations: [
    AppComponent,
    AddBookComponent,
    BookCardComponent,
    BookDetailComponent,
    BookListComponent,
    NavbarComponent,
    UserLoginComponent,
    UserRegisterComponent,
    HeaderComponent,
    CartComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [
    BookingService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
