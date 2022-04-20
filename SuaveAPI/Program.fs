namespace SuaveAPI
module Program =
    open Suave.Web
    open SuaveAPI.UserService
    open SuaveAPI.UserRepository
    [<EntryPoint>]
    let main argv =
        let userActions =
            handle
                "users"
                { ListUsers = UserRepository.getUsers
                  GetUser = UserRepository.getUser
                  AddUser = UserRepository.createUser
                  UpdateUser = UserRepository.updateUser
                  UpdateUserById = UserRepository.updateUserById
                  DeleteUser = UserRepository.deleteUser }
        startWebServer defaultConfig userActions
        0