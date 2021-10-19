"use strict";(self.webpackChunkclient=self.webpackChunkclient||[]).push([[7802],{7802:(g,l,a)=>{a.r(l),a.d(l,{ion_tab:()=>c,ion_tabs:()=>d});var s=a(8239),i=a(3150),u=a(7330);const c=class{constructor(e){(0,i.r)(this,e),this.loaded=!1,this.active=!1}componentWillLoad(){var e=this;return(0,s.Z)(function*(){e.active&&(yield e.setActive())})()}setActive(){var e=this;return(0,s.Z)(function*(){yield e.prepareLazyLoaded(),e.active=!0})()}changeActive(e){e&&this.prepareLazyLoaded()}prepareLazyLoaded(){if(!this.loaded&&null!=this.component){this.loaded=!0;try{return(0,u.a)(this.delegate,this.el,this.component,["ion-page"])}catch(e){console.error(e)}}return Promise.resolve(void 0)}render(){const{tab:e,active:t,component:n}=this;return(0,i.h)(i.H,{role:"tabpanel","aria-hidden":t?null:"true","aria-labelledby":`tab-button-${e}`,class:{"ion-page":void 0===n,"tab-hidden":!t}},(0,i.h)("slot",null))}get el(){return(0,i.i)(this)}static get watchers(){return{active:["changeActive"]}}};c.style=":host(.tab-hidden){display:none !important}";const d=class{constructor(e){(0,i.r)(this,e),this.ionNavWillLoad=(0,i.e)(this,"ionNavWillLoad",7),this.ionTabsWillChange=(0,i.e)(this,"ionTabsWillChange",3),this.ionTabsDidChange=(0,i.e)(this,"ionTabsDidChange",3),this.transitioning=!1,this.useRouter=!1,this.onTabClicked=t=>{const{href:n,tab:r}=t.detail;if(this.useRouter&&void 0!==n){const h=document.querySelector("ion-router");h&&h.push(n)}else this.select(r)}}componentWillLoad(){var e=this;return(0,s.Z)(function*(){if(e.useRouter||(e.useRouter=!!document.querySelector("ion-router")&&!e.el.closest("[no-router]")),!e.useRouter){const t=e.tabs;t.length>0&&(yield e.select(t[0]))}e.ionNavWillLoad.emit()})()}componentWillRender(){const e=this.el.querySelector("ion-tab-bar");e&&(e.selectedTab=this.selectedTab?this.selectedTab.tab:void 0)}select(e){var t=this;return(0,s.Z)(function*(){const n=o(t.tabs,e);return!!t.shouldSwitch(n)&&(yield t.setActive(n),yield t.notifyRouter(),t.tabSwitch(),!0)})()}getTab(e){var t=this;return(0,s.Z)(function*(){return o(t.tabs,e)})()}getSelected(){return Promise.resolve(this.selectedTab?this.selectedTab.tab:void 0)}setRouteId(e){var t=this;return(0,s.Z)(function*(){const n=o(t.tabs,e);return t.shouldSwitch(n)?(yield t.setActive(n),{changed:!0,element:t.selectedTab,markVisible:()=>t.tabSwitch()}):{changed:!1,element:t.selectedTab}})()}getRouteId(){var e=this;return(0,s.Z)(function*(){const t=e.selectedTab&&e.selectedTab.tab;return void 0!==t?{id:t,element:e.selectedTab}:void 0})()}setActive(e){return this.transitioning?Promise.reject("transitioning already happening"):(this.transitioning=!0,this.leavingTab=this.selectedTab,this.selectedTab=e,this.ionTabsWillChange.emit({tab:e.tab}),e.active=!0,Promise.resolve())}tabSwitch(){const e=this.selectedTab,t=this.leavingTab;this.leavingTab=void 0,this.transitioning=!1,e&&t!==e&&(t&&(t.active=!1),this.ionTabsDidChange.emit({tab:e.tab}))}notifyRouter(){if(this.useRouter){const e=document.querySelector("ion-router");if(e)return e.navChanged("forward")}return Promise.resolve(!1)}shouldSwitch(e){return void 0!==e&&e!==this.selectedTab&&!this.transitioning}get tabs(){return Array.from(this.el.querySelectorAll("ion-tab"))}render(){return(0,i.h)(i.H,{onIonTabButtonClick:this.onTabClicked},(0,i.h)("slot",{name:"top"}),(0,i.h)("div",{class:"tabs-inner"},(0,i.h)("slot",null)),(0,i.h)("slot",{name:"bottom"}))}get el(){return(0,i.i)(this)}},o=(e,t)=>{const n="string"==typeof t?e.find(r=>r.tab===t):t;return n||console.error(`tab with id: "${n}" does not exist`),n};d.style=":host{left:0;right:0;top:0;bottom:0;display:-ms-flexbox;display:flex;position:absolute;-ms-flex-direction:column;flex-direction:column;width:100%;height:100%;contain:layout size style;z-index:0}.tabs-inner{position:relative;-ms-flex:1;flex:1;contain:layout size style}"}}]);