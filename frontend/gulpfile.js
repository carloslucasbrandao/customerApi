var gulp = require('gulp');
var jshint = require('gulp-jshint');
var clean = require('gulp-clean');
var concat = require('gulp-concat');
var uglify = require('gulp-uglify');
var htmlmin = require('gulp-htmlmin');
var cleanCSS = require('gulp-clean-css');
var runSequence = require('run-Sequence');
var rename = require('gulp-rename');

gulp.task('clean', function () {
	return gulp.src('publish/')
	.pipe(clean());
});

gulp.task('jshint', function () {
	return gulp.src('js/**/*.js')
	.pipe(jshint())
	.pipe(jshint.reporter('default'));
});


gulp.task('uglify', ['clean'], function(){
	return gulp.src(['bower_components/angular/angular.js',
                   'bower_components/angular-route/angular-route.js',
                   'bower_components/angular-ui-mask/dist/mask.js',
									 'bower_components/angular-input-masks/angular-input-masks-standalone.js',
                   'js/app.js',
                   'js/**/*.js'])
	.pipe(uglify())
	.pipe(concat('scripts.js'))
	.pipe(gulp.dest('publish/js'));
});

gulp.task('htmlmin', function () {
	return gulp.src('view/*.html')
	.pipe(htmlmin({collapseWhitespace: true}))
	.pipe(gulp.dest('publish/view'))
});

gulp.task('cssmin', function () {
	return gulp.src(['bower_components/bootstrap/dist/css/bootstrap.css'])
	.pipe(cleanCSS())
	.pipe(concat('styles.min.css'))
	.pipe(gulp.dest('publish/css'));
});

gulp.task('copy', function () {
	return gulp.src('index_producao.html')
	.pipe(rename('index.html'))
	.pipe(gulp.dest('publish/'));
});

//gulp.task('default', ['webserver']);
gulp.task('default', function(cb){
	return runSequence('clean', ['jshint', 'uglify','htmlmin', 'cssmin', 'copy'], cb);
});
