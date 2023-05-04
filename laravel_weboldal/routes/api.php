<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;
use App\Http\Controllers\PetController;
use App\Http\Controllers\UserController;
use App\Http\Controllers\StateController;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| is assigned the "api" middleware group. Enjoy building your API!
|
*/



Route::get('/dogs',[PetController::class,'dogs']);
Route::get('/cats',[PetController::class,'cats']);
Route::get('/others',[PetController::class,'others']);
Route::get('/allat/{id}',[PetController::class,'show']);
Route::get('/allat/{id}/adoption',[PetController::class,'adoption']);
Route::get('/user/{id}',[PetController::class,'userpets']);
Route::get('/states',[StateController::class,'showall']);
Route::post('/user/newpet',[PetController::class,'newpet']);
Route::middleware('auth:sanctum')->get('/user', function (Request $request){
    return $request->user();
});

Route::post('/register', [UserController::class, 'register']);
Route::post('/login',[UserController::class,'login']);