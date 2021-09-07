import java.io.IOException;
import javax.websocket.Endpoint;
import javax.websocket.EndpointConfig;
import javax.websocket.RemoteEndpoint;
import javax.websocket.Session;
import javax.websocket.server.ServerEndpoint;
import java.text.SimpleDateFormat;
import java.util.Date;

//аннотации заявляет, что класс является веб-сокет, который будет развернут и доступен в URI пространства сервера веб-сокетов;
@ServerEndpoint("/websock")
public class websock extends Endpoint { //Класс Endpoint держит методы жизненного цикла , которые могут быть переопределены , чтобы перехватить WebSocket

    @Override
    public void onOpen(Session session, EndpointConfig endpointConfig){
        RemoteEndpoint.Basic remoteEndpointBasic = session.getBasicRemote(); // для синхронной отправки
        SimpleDateFormat format = new SimpleDateFormat("hh:mm:ss");
        try{
            while(true){
                Thread.sleep(2000);
                remoteEndpointBasic.sendText(format.format(new Date()));
            }
        }
        catch( IOException e){
            e.printStackTrace();
        }
        catch (InterruptedException e){
            e.printStackTrace();
        }
    }
}