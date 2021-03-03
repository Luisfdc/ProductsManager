import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CurrencyMaskModule } from "ng2-currency-mask";
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { SettingsComponent } from './components/settings/settings.component';
import { MenuComponent } from './components/menu/menu.component';
import { ProductService } from './services/product.service';
import { AuthenticationService } from './services/authentication.service';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ListProductsComponent } from './components/list-products/list-products.component';
import { CreateProductsComponent } from './components/create-products/create-products.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './auth-guard';
import { HomeComponent } from './components/home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    SettingsComponent,
    MenuComponent,
    ListProductsComponent,
    CreateProductsComponent,
    LoginComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    CurrencyMaskModule,
    RouterModule.forRoot([
      { path: 'ProductList', component: ListProductsComponent, canActivate: [AuthGuard] },
      { path: 'Product', component: CreateProductsComponent, canActivate: [AuthGuard] },
      { path: 'Product/:id', component: CreateProductsComponent, canActivate: [AuthGuard] },
      { path: 'login', component: LoginComponent },
      { path: '', component: HomeComponent, canActivate: [AuthGuard] },

      // otherwise redirect to home
      { path: '**', redirectTo: '' }
    ])
  ],
  providers: [
    ProductService,
    AuthenticationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
