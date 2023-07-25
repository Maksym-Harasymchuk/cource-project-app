// using System.Threading.Tasks;
// using Microsoft.AspNetCore.SignalR;
//
// namespace CourceProject.SignalR;
//
// public class ChatHub: Hub
// {
//     public async Task SendComment()
//     {
//         var car = await _context.Cars.FindAsync(carId);
//         
//         var comment = new Comment
//         {
//             Id = carId,
//             Body = body,
//             Car = null
//         };
//         
//         car.Comments.Add(comment);
//     }
// }