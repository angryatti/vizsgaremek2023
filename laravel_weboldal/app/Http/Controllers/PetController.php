<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\Pet;

class PetController extends Controller
{
    public function dogs()
    {
        return Pet::where('breed','kutya')->get();
    }
    public function cats()
    {
        return Pet::where('breed','macska')->get();
    }
    public function show($id)
    {
        return Pet::where('id',$id)->get();
    }
}