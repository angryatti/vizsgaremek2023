<?php

namespace App\Http\Controllers;

use App\Http\Requests\StorePetRequest;
use Illuminate\Http\Request;
use App\Models\Pet;
use App\Models\Advert;

class PetController extends Controller
{
    public function dogs()
    {
        $dog = 'kutya';
        $adverts = Advert::whereHas('pet', function($query) use ($dog) {
            $query->where('breed', $dog);
        })
        ->with('pet','state')
        ->get();
        return $adverts;
    }
    public function cats()
    {
        $cat = 'macska';
        $adverts = Advert::whereHas('pet', function($query) use ($cat) {
            $query->where('breed', $cat);
        })
        ->with('pet','state')
        ->get();
        return $adverts;
    }
    public function others()
    {
        $other = 'egyeb';
        $adverts = Advert::whereHas('pet', function($query) use ($other) {
            $query->where('breed', $other);
        })
        ->with('pet','state')
        ->get();
        return $adverts;
    }
    public function show($id)
    {
       $advert = Advert::where('id',$id)
        ->with('user','pet','state')
        ->firstOrFail();
        
        return $advert;
    }

    public function home(){
        return route('home');
    }
    
}