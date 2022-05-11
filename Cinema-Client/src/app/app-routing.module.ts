import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AccueilComponent } from "./accueil/accueil.component";
import { AuthGuard } from "./guard/auth.guard";
import { LoginComponent } from "./modules/login/login.component";
import { UsersComponent } from "./users/users.component";

const routes : Routes = [
    {path: "", component: AccueilComponent },
    {path: "users", component: UsersComponent},
    {path: "login", component: LoginComponent}
]
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule {}