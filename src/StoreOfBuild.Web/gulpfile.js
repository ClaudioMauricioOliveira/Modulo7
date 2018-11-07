var gulp = require('gulp');
var concat = require('gulp-concat');
var cssmin = require('gulp-cssmin');
var uncss = require('gulp-uncss');
var browserSync = require('browser-sync').create();

gulp.task('browser-sync', function () {
    browserSync.init({
        proxy: 'localhost:5000'
    });

    gulp.watch('./styles/*.css', ['css']);
    gulp.watch('./js/*.js', ['js']);
});

gulp.task('js', function () {
    return gulp.src([
        './node_modules/bootstrap/dist/js/bootstrap.min.js',
        './node_modules/jquery-ajax-unobtrusive/jquery.unobtrusive-ajax.min.js',
        './node_modules/jquery/dist/jquery.min.js',
        './node_modules/jquery-validation/dist/jquery.validate.min.js',
        './node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.js',
        './js/**/*.js',
    ])
        .pipe(gulp.dest('wwwroot/js/'))
        .pipe(browserSync.stream());
});

gulp.task('css', function () {
    return gulp.src([
        './Style/site.css',
        './node_modules/bootstrap/dist/css/bootstrap.css',
    ])
        .pipe(concat('site.min.css'))
        .pipe(cssmin())
        .pipe(uncss({ html: ['Views/**/*.cshtml'] }))
        .pipe(gulp.dest('wwwroot/css'))
        .pipe(browserSync.stream());
});

gulp.task('fonts', function () {

    return gulp.src([
        './node_modules/glyphicons-only-bootstrap/fonts/glyphicons-halflings-regular.eot',
        './node_modules/glyphicons-only-bootstrap/fonts/glyphicons-halflings-regular.svg',
        './node_modules/glyphicons-only-bootstrap/fonts/glyphicons-halflings-regular.ttf',
        './node_modules/glyphicons-only-bootstrap/fonts/glyphicons-halflings-regular.woff',
        './node_modules/glyphicons-only-bootstrap/fonts/glyphicons-halflings-regular.woff2'
    ])
        .pipe(gulp.dest('wwwroot/fonts'))
        .pipe(browserSync.stream());
});
