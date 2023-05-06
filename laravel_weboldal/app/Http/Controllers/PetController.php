<?php

namespace App\Http\Controllers;

use App\Http\Requests\StorePetRequest;
use Illuminate\Http\Request;
use App\Models\Pet;
use App\Models\Advert;
use Illuminate\Support\Facades\Log;
use Illuminate\Support\Facades\Storage;

class PetController extends Controller
{
    public function dogs()
    {
        $dog = 'kutya';
        $adverts = Advert::whereHas('pet', function($query) use ($dog) {
            $query->where('species', $dog);
        })
        ->with('pet','state')
        ->get();
        return $adverts;
    }
    public function cats()
    {
        $cat = 'macska';
        $adverts = Advert::whereHas('pet', function($query) use ($cat) {
            $query->where('species', $cat);
        })
        ->with('pet','state')
        ->get();
        return $adverts;
    }
    public function others()
    {
        $other = 'egyeb';
        $adverts = Advert::whereHas('pet', function($query) use ($other) {
            $query->where('species', $other);
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

    public function adoption($id)
    {
       $advert = Advert::where('id',$id)
        ->with('user','pet','state')
        ->firstOrFail();
        
        return $advert;
    }

    public function home(){
        return route('home');
    }
    
    public function userpets($id){
        $pets = Advert::where('user_id',$id)
        ->with('user','pet','state')
        ->get();

        return $pets;
    }

    public function newpet(StorePetRequest $request){

        Log::debug($request);
        $validated = $request->validated();

        $pet = Pet::create([
            'pet_name' => $validated['pet_name'],
            'born' => $validated['born'],
            'breed' => $validated['breed'],
            'species' => $validated['species'],
            'gender' => $validated['gender'],
            'castrated' => $validated['castrated'],
            'img_userdefine' => $validated['img'],
            'description' => $validated['description'],
        ]);
        $advert = Advert::create([
            'state_id' => $validated['state_id'],
            'contact_info' => $validated['contact_info'],
            'pet_id' => $pet['id'],
            'user_id' => $validated['user_id'],
        ]);
        $image = $request->file('imagepreview');
        $imagename = $pet->img_userdefine;
         $image->storeAs('public/pet_imgs',$imagename);

        $success['pet'] = $pet;
        $success['advert'] = $advert;

        $response = [
            'success' => true,
            'data' => $success,
            'message'=>'Sikeresen feltetted a hirdetést!'
        ];
        return response()->json($response);
    }

    
}