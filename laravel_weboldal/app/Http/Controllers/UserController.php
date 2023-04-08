<?php

namespace App\Http\Controllers;

use App\Http\Requests\StoreUserRequest;
use App\Models\User;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Hash;
use Illuminate\Support\Facades\Validator;

class UserController extends Controller
{
    public function login(Request $request){
        $validate = Validator::make($request->all(),[
            'email' =>'required|email',
            'password'=>'required'
        ]);
        if($validate->fails()){
            return response()->json([
                'errors' =>$validate->errors(),
            ],422);
        }

        if(!$token = Auth::attempt($request->only(['email','password']))){
            return response()->json([
                'error' => 'Unauthorized',
            ],401);
        }

        return response()->json([
            'token' => $token
        ]);
    }


    public function register(Request $request)
    {
        $validated = $request->validate([
            'email' => 'required|email|unique:users,email',
            'user_name' =>'required|unique:users,user_name',
            'password' => 'required'
        ]);
        $user = User::create([
            'email' => $validated['email'],
            'user_name' => $validated['user_name'],
            'password' => Hash::make($validated['password'])
        ]);
        return response()->Json(['message'=>'Sikeresen Regisztráltál az Oldalra']);
    }

    /**
     * Display the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function show($id)
    {
        //
    }

    /**
     * Show the form for editing the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function edit($id)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function update(Request $request, $id)
    {
        //
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function destroy($id)
    {
        //
    }
}
