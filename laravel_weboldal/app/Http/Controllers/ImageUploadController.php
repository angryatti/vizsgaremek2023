<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class ImageUploadController extends Controller
{
    public function upload(Request $request)
    {
        if($request->hasFile('file')) {
            $file = $request->file('file');

            if($file->isValid()) {
                $filePath = $file->storeAs('public/pet_imgs','dogs_template.jpg');
               // $fileName= basename($filePath);
            
                return redirect()->back()->with('message','Fájl feltöltve.');
            }
        }
     //   return view('layouts.upload');
    }
}
