﻿/*
 *
 */
package urlshorten
{
	import flash.events.Event;
	import flash.events.IOErrorEvent;
	import flash.events.SecurityErrorEvent;
	import flash.events.EventDispatcher;
	import flash.net.URLLoader;
	import flash.net.URLRequest;
	import flash.net.URLVariables;
	import flash.net.URLRequestMethod;
	import flash.utils.Dictionary;

	import urlshorten.events.URLShortenEvent;
	
	/**
	 * 
	 */
	public class URLShorten extends EventDispatcher
	{
		/**
		 * 
		 */
		protected var services:Dictionary;

		/**
		 * 
		 */
		protected var defaultService:String = 'tinyurl';

		/**
		 * 
		 */
		public var projectUrl:String = 'http://code.google.com/p/urlshorten/';

		/**
		 * 
		 */
		public var lastURL:String;
		 
		/**
		 * 
		 */
		public function URLShorten():void
		{
		}

		/**
		 * 
		 */
		public function factory(...args:Array):void
		{
			if (args.length < 1)
				throw new Error("Invalid number of arguments");	

			var url:String = args[0];
			var service:String = args[1] ? args[1] : this.defaultService;
	
			if (!this.isURLValid(url))
				throw new Error('URL invalid ("'+ url +'")');	
				
			if (!this.serviceExists(service))
				throw new Error('This service ("'+ service +'") doesn\'t exist');
			

			this.lastURL = url;

			if (args[1])
				args.splice(1, 1);
			this[service].apply(this, args);
		}
		 
		/**
		 * TinyURL service
		 * 
		 * @param	url	An URL string
		 */
		public function tinyurl(url:String):void
		{
			var service:Object = this.getService('tinyurl');
			var loader:URLLoader = this.getLoader('tinyurl', this.tinyurlHandler);
			
			url = service.api + url;
			var request:URLRequest = new URLRequest(url);
			loader.load(request);
		}
		
		/**
		 * supr service
		 * 
		 * @param	url	An URL string
		 */
		public function supr(url:String):void
		{
			var service:Object = this.getService('supr');
			var loader:URLLoader = this.getLoader('supr', this.tinyurlHandler);
			
			url = service.api + url;
			var request:URLRequest = new URLRequest(url);
			loader.load(request);
		}
		 
		/**
		 * is.gd service
		 * 
		 * @param	url	An URL string
		 */
		public function isgd(url:String):void
		{
			var service:Object = this.getService('isgd');
			var loader:URLLoader = this.getLoader('isgd', this.isgdHandler);
			
			url = service.api + url;
			var request:URLRequest = new URLRequest(url);
			loader.load(request);
		}
		 
		/**
		 * snurl service
		 * 
		 * @param	url	An URL string
		 */
		public function snurl(url:String):void
		{
			var service:Object = this.getService('snurl');
			var loader:URLLoader = this.getLoader('snurl', this.snurlHandler);
			
			url = service.api + url;
			var request:URLRequest = new URLRequest(url);
			loader.load(request);
		}
		 
		/**
		 * Migre.me service
		 * 
		 * Based on: http://code.google.com/p/migreme-as3/
		 * 
		 * @param	url	An URL string
		 */
		public function migreme(url:String):void
		{
			var service:Object = this.getService('migreme');
			var loader:URLLoader = this.getLoader('migreme', this.migremeHandler);
			
			url = service.api + url;
			var request:URLRequest = new URLRequest(url);
			loader.load(request);
		}
		 
		/**
		 * Bit.ly service
		 *  
		 * @param	url	An URL string
		 */
		public function bitly(url:String, login:String, apiKey:String, version:String=null):void
		{
			var service:Object = this.getService('bitly');
			var loader:URLLoader = this.getLoader('bitly', this.bitlyHandler);
			
			var params:Dictionary = new Dictionary();
			params['longUrl'] = url;
			params['login'] = login;
			params['apiKey'] = apiKey;
			params['version'] = (version == null) ? service.version : version
			params['format'] = "xml";
			
			url = service.api +'?' + this.getQueryString(params);
			trace("bitly url : "+url);
			var request:URLRequest = new URLRequest(url);
			loader.load(request);
		}
		 
		/**
		 * Digg Shorten service
		 * 
		 * @param	url	An URL string
		 */
		public function digg(url:String, appkey:String=null):void
		{	
			var service:Object = this.getService('digg');
			var loader:URLLoader = this.getLoader('digg', this.diggHandler);
		
			if (appkey == null)
				appkey = this.projectUrl;
			
			var params:Dictionary = new Dictionary();
			params['appkey'] = appkey;
			
			url = service.api + url +"&" + this.getQueryString(params);
			var request:URLRequest = new URLRequest(url);
			loader.load(request);
		}
		 
		/**
		 * tr.im Shorten service
		 * 
		 * @param	url	An URL string
		 */
		public function trim(url:String, username:String=null, password:String=null):void
		{	
			var service:Object = this.getService('trim');
			var loader:URLLoader = this.getLoader('trim', this.trimHandler);
			
			var params:Dictionary = new Dictionary();
			params['url'] = url;
			if (username != null && password != null)
			{
				params['username'] = username;
				params['password'] = password;
			}
			
			url = service.api + "?" + this.getQueryString(params);			
			var request:URLRequest = new URLRequest(url);
			loader.load(request);
		}
		
		
		
		// Protected Handlers		
		 
		/**
		 * TinyURL Complete Handler
		 * 
		 * @param	event
		 */
		protected function tinyurlHandler(event:Event):void
		{
			var loader:URLLoader = this.getLoader('tinyurl');
			var url:String = loader.data;
			this.dispatchURLShortenEvent(url, 'tinyurl', loader.data);
		}
		
		/**
		 * is.gd Complete Handler
		 * 
		 * @param	event
		 */
		protected function isgdHandler(event:Event):void
		{
			var loader:URLLoader = this.getLoader('isgd');
			var url:String = loader.data;			
			this.dispatchURLShortenEvent(url, 'isgd', loader.data);
		}
		
		/**
		 * snurl Complete Handler
		 * 
		 * @param	event
		 */
		protected function snurlHandler(event:Event):void
		{
			var loader:URLLoader = this.getLoader('snurl');
			var url:String = loader.data;			
			this.dispatchURLShortenEvent(url, 'snurl', loader.data);
		}
		
		/**
		 * Migre.me Complete Handler
		 * 
		 * Based on: http://code.google.com/p/migreme-as3/
		 * 
		 * @param	event
		 */
		protected function migremeHandler(event:Event):void
		{
			var loader:URLLoader = this.getLoader('migreme');
			var xml:XML = new XML(loader.data);
			var data:Object = new Object();
            for each (var tempXML:XML in xml.children())
			{
				data[tempXML.name()] = tempXML;
			}
			var url:String = data.migre;
			this.dispatchURLShortenEvent(url, 'migreme', loader.data);
		}
		
		/**
		 * bitly Complete Handler
		 * 
		 * @param	event
		 */
		protected function bitlyHandler(event:Event):void
		{
			var loader:URLLoader = this.getLoader('bitly');
			var xml:XML = new XML(loader.data);
			trace("xml:"+xml);
			var data:Object = new Object();
            for each (var tempXML:XML in xml.children())
			{
				data[tempXML.name()] = tempXML;
			}
			var url:String = data.results.nodeKeyVal.shortUrl;
			this.dispatchURLShortenEvent(url, 'bitly', loader.data);
		}
		
		/**
		 * supr Complete Handler
		 * 
		 * @param	event
		 */
		protected function suprHandler(event:Event):void
		{
			var loader:URLLoader = this.getLoader('supr');
			var url:String = loader.data;
			this.dispatchURLShortenEvent(url, 'supr', loader.data);
			
			/*
			var loader:URLLoader = this.getLoader('supr');
			var xml:XML = new XML(loader.data);
			var data:Object = new Object();
            for each (var tempXML:XML in xml.children())
			{
				data[tempXML.name()] = tempXML;
			}
			var url:String = data.shorturl.@short_url;
			this.dispatchURLShortenEvent(url, 'supr', loader.data);
			*/
		}
		
		/**
		 * Digg Complete Handler
		 * 
		 * @param	event
		 */
		protected function diggHandler(event:Event):void
		{
			var loader:URLLoader = this.getLoader('digg');
			var xml:XML = new XML(loader.data);
			var data:Object = new Object();
            for each (var tempXML:XML in xml.children())
			{
				data[tempXML.name()] = tempXML;
			}
			var url:String = data.shorturl.@short_url;
			this.dispatchURLShortenEvent(url, 'digg', loader.data);
		}
		
		/**
		 * tr.im Complete Handler
		 * 
		 * @param	event
		 */
		protected function trimHandler(event:Event):void
		{
			var loader:URLLoader = this.getLoader('trim');
			var xml:XML = new XML(loader.data);
			var data:Object = new Object();
            for each (var tempXML:XML in xml.children())
			{
				data[tempXML.name()] = tempXML;
			}
			var url:String = data.url;
			this.dispatchURLShortenEvent(url, 'trim', loader.data);
		}
		
		
		
		// Protected Helper methods
		
		/**
		 * Dispatch an Event with the URL
		 * 
		 * @param	url
		 */
		protected function dispatchURLShortenEvent(url:String, service:String, data:Object=null):void
		{
			trace("dispatchURLShortenEvent : "+url);
			var event:URLShortenEvent = new URLShortenEvent(URLShortenEvent.ON_URL_SHORTED);
			event.service = service;
			event.url = url;
			event.data = data
			this.dispatchEvent(event);
		}

		/**
		 * Error Handler
		 * 
		 * @param	errorEvent
		 */
		protected function errorHandler(errorEvent:IOErrorEvent):void
		{
			var event:URLShortenEvent = new URLShortenEvent(URLShortenEvent.ON_ERROR);
			event.data = errorEvent.text;
			this.dispatchEvent(event);
		}
		
		/**
		 * 
		 * 
		 * @param	url
		 */
		protected function getQueryString(params:Dictionary):String
		{
			var result:Array = new Array();
			for (var key:Object in params)
			{
				result.push( String(key) +"="+ String(params[key]) );
			}			
			return result.join("&");
		}
		 
		/**
		 * 
		 */
		protected function getLoader(serviceName:String, completeHandler:Function=null):URLLoader
		{
			var service:Object = this.getService(serviceName);
			if (!service.loader)
			{
				var loader:URLLoader = new URLLoader();
				loader.addEventListener(Event.COMPLETE, completeHandler);
				loader.addEventListener(IOErrorEvent.IO_ERROR, this.errorHandler);
				loader.addEventListener(SecurityErrorEvent.SECURITY_ERROR, this.errorHandler);
				
				service.loader = loader;
			}
			return service.loader;
		}

		
		
		// Public Helper methods
		
		/**
		 * Returns true if valid url is found
		 * 
		 * Source: http://snipplr.com/view/12770/url-validation-via-regexp/
		 * 
		 * @param	url
		 * @return	true|false
		 */
		public function isURLValid(url:String):Boolean
		{
			var regex:RegExp = /^http(s)?:\/\/((\d+\.\d+\.\d+\.\d+)|(([\w-]+\.)+([a-z,A-Z][\w-]*)))(:[1-9][0-9]*)?(\/([\w-.\/:%+@&=]+[\w- .\/?:%+@&=]*)?)?(#(.*))?$/i;
			return regex.test(url);
		}
		 
		/**
		 * 
		 */
		public function serviceExists(service:String):Boolean
		{
			this.getServices();
			return (this.services[service] != null);
		}
		 
		/**
		 * 
		 */
		public function getService(service:String):Object
		{
			if (this.serviceExists(service))
				return this.services[service];
			return null;
		}
		 
		/**
		 * 
		 */
		public function getServices():Dictionary
		{
			if (!this.services)
			{
				this.services = new Dictionary();
				this.services['tinyurl'] = {
					name:'TinyURL',
					url:'http://tinyurl.com/',
					api:'http://tinyurl.com/api-create.php?url='
				};
				this.services['isgd'] = {
					name:'is.gd',
					url:'http://is.gd/',
					api:'http://is.gd/api.php?longurl='
				};
				this.services['snurl'] = {
					name:'SNURL',
					url:'http://snurl.com',
					api:'http://snipr.com/site/snip?r=simple&link='
				};
				this.services['migreme'] = {
					name:'Migre.me',
					url:'http://migre.me/',
					api:'http://migre.me/api.xml?url='
				};
				this.services['bitly'] = {
					name:'bit.ly',
					url:'http://bit.ly/',
					api:'http://api.bit.ly/shorten',
					version:'2.0.1'
				};
				this.services['digg'] = {
					name:'Digg',
					url:'http://digg.com/',
					api:'http://services.digg.com/url/short/create?url='
				};
				this.services['supr'] = {
					name:'su.pr',
					url:'http://su.pr/',
					api:'http://su.pr/api?url='
				};
				this.services['trim'] = {
					name:'tr.im',
					url:'http://tr.im/',
					api:'http://api.tr.im/api/trim_url.xml'
				};
			}
			return this.services;
		}
	}
	
}