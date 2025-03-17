import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UnauthorizedComponent } from './modules/shared/unauthorized/unauthorized.component';
import { AuthGuard } from './auth-guards/auth-guard.service';
import { ApartmentDetailsComponent } from './apartment-details/apartment-details.component';




const routes: Routes = [
  { path: 'apartment/:id', component: ApartmentDetailsComponent },


  { path: 'unauthorized', component: UnauthorizedComponent },
  {
    path: 'admin',
    canActivate: [AuthGuard],
    data: { isAdmin: true },
    loadChildren: () => import('./modules/admin/admin.module').then(m => m.AdminModule)
  },
  {
    path: 'public',
    loadChildren: () => import('./modules/public/public.module').then(m => m.PublicModule)
  },
  {
    path: 'client',
    loadChildren: () => import('./modules/client/client.module').then(m => m.ClientModule)
  },
  {
    path: 'auth',
    loadChildren: () => import('./modules/auth/auth.module').then(m => m.AuthModule)
  },
  { path: '**', redirectTo: 'public', pathMatch: 'full' }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
