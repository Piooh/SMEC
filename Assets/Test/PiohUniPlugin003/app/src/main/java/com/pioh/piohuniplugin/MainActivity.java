package com.pioh.piohuniplugin;

import android.os.Bundle;

import com.unity3d.player.UnityPlayer;
import com.unity3d.player.UnityPlayerActivity;

public class MainActivity extends UnityPlayerActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) { super.onCreate(savedInstanceState); }

    public int PluginSum( int value1, int value2 ) { return value1 + value2; }

    public void PluginMessage() { UnityPlayer.UnitySendMessage( "PiohUniPlugin", "ReceiveMessage", "Hello!!! Unity!! I am Plugin Method" ); }

}
