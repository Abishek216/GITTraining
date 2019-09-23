using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApp2.Models
{
    public class MovieInitializer:System.Data.Entity.DropCreateDatabaseIfModelChanges<MovieContext>
    {
        protected override void Seed(MovieContext context)
        {
            var moviesCategory = new List<MoviesCategory>
            {
                new MoviesCategory{CategoryName = "Action" },
                new MoviesCategory{CategoryName = "Comedy"},
                new MoviesCategory{CategoryName = "Thriller" }

            };

            moviesCategory.ForEach(s => context.MoviesCategories.Add(s));
            context.SaveChanges();

            var moviesLanguage = new List<MoviesLanguage>
            {
                new MoviesLanguage{MoviesLanguageName = "English" },
                new MoviesLanguage{MoviesLanguageName = "Hindi"}
              

            };
            moviesLanguage.ForEach(s => context.MoviesLanguages.Add(s));
            context.SaveChanges();

            var streamingPlatform = new List<StreamingPlatform>
            {
                new StreamingPlatform{StreamingPlatformName="Netflix"},
                new StreamingPlatform{StreamingPlatformName="Amazon Prime"}
            };

            streamingPlatform.ForEach(s => context.StreamingPlatforms.Add(s));
            context.SaveChanges();


            var movie = new List<Movie>
            {

                new Movie{MovieName="Movie 1", MovieYearOfRelease = "2000", CategoryId = 1, MoviesLanguageId = 1, MovieDirectorName = "Director1", StreamingPlatformId = 1},
                new Movie{MovieName="Movie 2", MovieYearOfRelease = "2001", CategoryId = 1, MoviesLanguageId = 2, MovieDirectorName = "Director2",  StreamingPlatformId = 2},
                new Movie{MovieName="Movie 3", MovieYearOfRelease = "2002", CategoryId = 2, MoviesLanguageId = 1, MovieDirectorName = "Director3",  StreamingPlatformId = 1}

             
            };

           

            movie.ForEach(s => context.Movies.Add(s));
            context.SaveChanges();
            var user = new List<User>
            {
                new User{UserName="Abishek216",Password="abishek123"},
                new User{UserName="AjayM",Password="ajay1234"}
            };
            user.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

            var role = new List<Role>
            {
                new Role{RoleName="Admin"},
                new Role{RoleName="Premium"},
                new Role{RoleName="Free"}
            };
            role.ForEach(r => context.Roles.Add(r));
            context.SaveChanges();

            var urole = new List<UserRoleMapping>
            {
                new UserRoleMapping{UserId=1,RoleId=1},
                new UserRoleMapping{UserId=2,RoleId=2}
            };
            urole.ForEach(u => context.UserRoleMappings.Add(u));
            context.SaveChanges();
        }
    }
}