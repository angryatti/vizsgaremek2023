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
                    //saját hash-re cseréljük majd
                $dbName = md5($file->getClientOriginalName()).".jpg";


                $filePath = $file->storeAs('public/pet_imgs',$dbName);
               // $fileName= basename($filePath);
            
                return redirect()->back()->with('message','Fájl feltöltve.');
            }
        }
    }

    public function uploadFrontend(Request $request)
    {
        $validated = $request->validate([
            'image' => 'required|image|max:2048', // max size of 2MB
        ]);
        $path = $request->file('image')->store('public/pet_imgs');
        return ['path' => asset($path)];
    }
}
