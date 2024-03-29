<?php

namespace App\Http\Controllers;

use App\Http\Requests\StoreUserRequest;
use App\Http\Requests\LoginRequest;
use App\Http\Requests\UpdateUserRequest;
use Illuminate\Support\Facades\Auth;
use App\Models\User;
use Illuminate\Contracts\Session\Session;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Hash;
use Illuminate\Support\Facades\Validator;

class UserController extends Controller
{
    
    public function register(StoreUserRequest $request)
    {
        $validated = $request->validated();
        $user = User::create([
            'email' => $validated['email'],
            'user_name' => $validated['user_name'],
            'password' => bcrypt($validated['password'])
        ]);
        $success['token'] = $user->createToken('auth_token')->plainTextToken;
        $success['user'] = $user->user_name;

        $response = [
            'success' => true,
            'data' => $success,
            'message'=>'Sikeresen Regisztráltál az Oldalra'
        ];
        return response()->Json([$response,200]);
    }

    public function login(Request $request){
        if(Auth::attempt(['email'=>$request->email,'password'=>$request->password]))
        {
            //$user = Auth::user();
            $user = $request->user();
            $success['token'] = $user->createToken('auth_token')->plainTextToken;
            $success['user_id'] = $user->id;

            $response = [
                'success' => true,
                'data' => $success,
                'message' => 'Sikeresen bejelentkeztél'
            ];

        return response()->Json($response, 200);
        }
        else
        {
            $response = [
                'success' => false,
                'message' => 'Bejelentkezés nem sikerült'
            ];
            return response()->Json($response);
        }
    }

    /**
     * Display the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function logout()
    {

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
    public function update(UpdateUserRequest $request, $id)
    {
        $user = User::find($id);

        if (!$user) {
            return response()->json(['message' => 'User not found'], 404);
        }

        $validated = $request->validated();
        
        $user->update($validated);

        return response()->json(['message' => 'User updated successfully', 'user' => $user]);
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
